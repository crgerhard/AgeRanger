<%@ WebHandler Language="C#" Class="Person" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using DebitSuccess;

public class Person : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var mode = context.Request["m"];
        var output = "";
        switch (mode)
        {
            case "g":
                output = getPersons();
                break;
            case "a":
                output = addUpdatePerson(context);
                break;
            case "d":
                var personId = Convert.ToInt64(context.Request["i"]);
                output = deletePerson(personId);
                break;
            case "s":
                output = searchPersons(context);
                break;
        }
        context.Response.Write(output);
    }

    private string getPersons()
    {
        var result = new List<DebitSuccess.BasePerson>();
        try
        {
            result = new DebitSuccess.PersonUT().ListWithAgeGroup();
        }
        catch (Exception ex)
        {

        }
        return new JavaScriptSerializer().Serialize(result);
    }

    private string addUpdatePerson(HttpContext context)
    {
        long result = 0;
        var basePerson = new DataContractJsonSerializer(typeof(BasePerson));
        try
        {
            var person = basePerson.ReadObject(context.Request.InputStream) as BasePerson;
            if (person != null)
            {
                if (person.id == 0)
                {
                    result = new DebitSuccess.PersonDB().Add(person);
                }
                else
                {
                    var updated = new DebitSuccess.PersonDB().Update(person);
                    result = updated ? 1 : 0;
                }
            }
        }
        catch (Exception ex)
        {

        }
        return new JavaScriptSerializer().Serialize("{\"success\":" + result.ToString());
    }

    private string deletePerson(long personId)
    {
        long result = 0;
        try
        {
            var deleted = new DebitSuccess.PersonDB().Delete(personId);
            result = deleted ? 1 : 0;
        }
        catch (Exception ex)
        {

        }
        return new JavaScriptSerializer().Serialize("{\"success\":" + result.ToString());
    }

    private string searchPersons(HttpContext context)
    {
        var result = new List<DebitSuccess.BasePerson>();
        var basePerson = new DataContractJsonSerializer(typeof(BasePerson));
        try
        {
            var person = basePerson.ReadObject(context.Request.InputStream) as BasePerson;
            if (person != null)
            {
                //WHERE [FIRSTNAME] LIKE '%CHRI%' AND [LASTNAME] LIKE '%GER1%';
                var sqlwhere = "";
                var firstName = false;
                if (person.firstName != "")
                {
                    sqlwhere += " WHERE [FIRSTNAME] LIKE '%" + person.firstName + "%'";
                    firstName = true;
                }
                if (person.lastName != "")
                {
                    if (!firstName)
                        sqlwhere += " WHERE [LASTNAME] LIKE '%" + person.lastName + "%'";
                    else
                        sqlwhere += " AND [LASTNAME] LIKE '%" + person.lastName + "%'";
                }
                result = new DebitSuccess.PersonUT().ListWithAgeGroup(sqlwhere);
            }
        }
        catch (Exception ex)
        {

        }
        return new JavaScriptSerializer().Serialize(result);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}