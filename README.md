# MRPanel

This is a Content Management System **(CMS)** based on [ABP](https://aspnetboilerplate.com/Templates). It has been optimised for Persian/English language.

To run the application please follow these instructions:

## ASP.NET Core Application

1. Open your solution in Visual Studio 2017 v15.3.5+ and build the solution.
2. Select the **'Web.Host'** project as the **startup project**.
3. Check the **connection string** in the **appsettings.json** file of the **Web.Host** project, change it if you need to.
4. Open the **Package Manager** Console and run an **Update-Database** command to create your database (ensure that the Default project is selected as **.EntityFrameworkCore** in the Package Manager Console window).
5. Run the application. It will show **swagger-ui** if it is successful:

	
![MRPanel Swagger](https://user-images.githubusercontent.com/1321544/102716909-b1e5e400-42d6-11eb-9514-292040bd15b8.png)

## Angular Admin Panel Application

1. Open a command prompt, navigate to the **angular-admin** folder which contains the *.sln file and run the **yarn install** to restore the packages.
2. In your opened command prompt, run **npm start** or **npm run hmr** command.
3. Once the application has compiled, you can go to [http://localhost:4200](http://localhost:4200) in your browser. Be sure that the **Web.Host** application is running at the same time. When you open the application, you will see the login page.
4. You can now login to the application using the default credentials. The default username is **admin** and the password is **123qwe**

![MRPanel Panel Admin](https://user-images.githubusercontent.com/1321544/102717014-83b4d400-42d7-11eb-8b7c-037c65298601.png)

## Angular Site Application

1. Open a command prompt, navigate to the **angular-site** folder and run the **yarn install** to restore the packages.
2. In your opened command prompt, run **npm start**.
3. Once the application has compiled, you can go to [http://localhost:4300](http://localhost:4300) in your browser.

![MRPanel Panel Site](https://user-images.githubusercontent.com/1321544/102717041-a515c000-42d7-11eb-8515-491276fab7aa.png)

*This project is still under development, I would appreciate any contribution.* - MRP