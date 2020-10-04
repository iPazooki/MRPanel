# MRPanel

This is a Content Management System **(CMS)** based on [ABP](https://aspnetboilerplate.com/Templates). It has been optimised for Persian/English language.

To run the application please follow these instructions:

## ASP.NET Core Application

1. Open your solution in Visual Studio 2017 v15.3.5+ and build the solution.
2. Select the **'Web.Host'** project as the **startup project**.
3. Check the **connection string** in the **appsettings.json** file of the **Web.Host** project, change it if you need to.
4. Open the **Package Manager** Console and run an **Update-Database** command to create your database (ensure that the Default project is selected as **.EntityFrameworkCore** in the Package Manager Console window).
5. Run the application. It will show **swagger-ui** if it is successful:

	
![MRPanel Swagger](https://raw.githubusercontent.com/aspnetboilerplate/aspnetboilerplate/master/doc/WebSite/images/swagger-ui-module-zero-core-template.png)

## Angular Admin Panel Application

1. Open a command prompt, navigate to the **angular** folder which contains the *.sln file and run the **yarn install** to restore the packages.
2. In your opened command prompt, run **npm start** or **npm run hmr** command.
3. Once the application has compiled, you can go to [http://localhost:4200](http://localhost:4200) in your browser. Be sure that the **Web.Host** application is running at the same time. When you open the application, you will see the login page.
4. You can now login to the application using the default credentials. The default username is **admin** and the password is **123qwe**

![MRPanel Panel](https://raw.githubusercontent.com/aspnetboilerplate/aspnetboilerplate/master/doc/WebSite/images/module-zero-core-template-ui-home.png)

## Angular Site Application

1. Open a command prompt, navigate to the **angular-site** folder and run the **yarn install** to restore the packages.
2. In your opened command prompt, run **npm start**.
3. Once the application has compiled, you can go to [http://localhost:4300](http://localhost:4300) in your browser.

*This project is still under development* - MRP