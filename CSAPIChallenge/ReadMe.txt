Instructions:

1. Application is pointing to Local Instance of SQL Server. DB Name is:
Please Change Web.config if needed
<add name="CSApiTest" connectionString="Data Source=LocalHost;Initial Catalog=CSApiTest;Integrated Security=True; MultipleActiveResultSets=true" providerName="System.Data.SqlClient" />
2.


To test API:
1. Run CSApiCalenge MVC solution and write down port number
2. Run WebClinet Console Application and enter this port number when prompted
3. Follow further prompts




Changes:
V1.

1. Code tided - removed vievs and models we do not need here
2. Added some simple image (Try to find better one)

V2.
Repository helper calsses Names Changed to ISiteRepository and SQLSiteRepository
-  Added the following in AppStart\WebApiConfig

            config.Routes.MapHttpRoute(

                name: "DefaultApi2",

                routeTemplate: "api/{controller}/{action}",

                defaults: new { id = RouteParameter.Optional }


--- Tried to add this to view


$(document).ready(function(){
$.getJSON('http://localhost:50297/api/ApiCSUser/GetAllCSUsers').done(function (data){
    $.each(data, function (key,item){
        $('<li>, { text: formatItem(item)}).appentTo($('#GetAllCSUsers'));
        });
    });

});

But does not work

