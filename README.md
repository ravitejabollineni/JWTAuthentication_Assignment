# JWTAuthentication_Assignment
Implement JSON Web Token based Authenitication for the entire Web API
0
 
GLP of JQuery
Asp.Net Core Web API Assignments
July 2020
This document is confidential and contains proprietary information, including trade secrets of CitiusTech. Neither the document nor 
any of the information contained in it may be reproduced or disclosed to any unauthorized person under any circumstances 
without the express written permission of CitiusTech.
1
 
GLP of JQuery
Document Control
Version 1.0
Created by Ajit Jog
Updated by Ajit Jog
Reviewed by Vaishali Desai
Date July 2020
Earlier versions
2
 
GLP of JQuery

GLP of JQuery
Lab Assignment 1
Create a class library project ContactsLib with following
public class Contact
{
public Int ContactNo {get;set};
public String ContactName {get;set};
public String City {get;set};
public String CellNo {get;set};
}
public Interface IContactRepo
{
void AddContact(Contact c);
void List <Contact> GetContacts();
void UpdateContact(Contact c);
void DeleteContact(int contactid;
void List <Contact> GetContactsByCity(string city)
}
public class InMemoryContactRepo: IContactRepo
{
}
Note: The class InMemoryContactRepo should implement all the interface functions by storing data in memory.
Hint: Use a generic singleton collection instance to store multiple contact details in memory
Validation Requirements
4
 
GLP of JQuery
• Contact No to be numeric
• Contact Name should not have numbers
• CellNo exactly 10 digits
Create a Asp.Net Core Web API project (ContactsApi). Add appropriate controller actions for the following
• Add a contact
• Update Contact details
• Delete a contact
• Get all Contacts
• Get all Contacts by City
The API Controller actions will make calls to corresponding functions in the IContactRepo implementor class that is 
injected. In this lab the in memory implementation.
Use Dependency Service Injection to inject the dependencies whereever required
Use POSTMAN or Fiddler to test all the API Controller actions
Lab Assignment 2
Add the following interface and in memory implementation class in class library project above (ContactsLib)
public Interface ICitiesRepo
{
void List <string> GetCities);
}
Note: Create a InMemoryCitiesRepo implementor class in ContactsLib which maintains master cities list in generic 
collection.
Perform the below additional validation in addition to mentioned in Assignment1:
CityName should be one among the list returned by InMemoryCitiesRepo implementor
Perform custom validation creating a custom filter attribute.
Lab Assignment 3
Create corresponding Contacts and Cities table in database.
Cities table will have only CityName column. 
In ContactsLib create IContactsRepo and ICitiesRepo implementor classes using the above database tables and inject 
them instead of the earlier InMemory implementor classes and test the API controller actions again.
5
 
GLP of JQuery
Lab Assignment 4
Configure CORS to allow only get operations from all origin site.
Create a simple HTML page with 2 button “Get All Contacts” and “Get Contacts By City” and test the following API 
controller actions by calling them using JQuery AJAX ($.Ajax() function)
• Get all Contacts
• Get all Contacts by City
For calling Get all Contacts by City API controller action accept city name using HTML TextBox in web page.
Lab Assignment 5
Implement JSON Web Token based Authenitication for the entire Web API
