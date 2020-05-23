# About
This code sample requires DataScript.sql to be executed prior to running code in this project.

### Bad connection
As coded the connection string is incorrect using a private variable  **ConnectionStringFails**, although a bad connection string the application remains responsive unlike using .Open method of the connection. Change the connection string to **ConnectionStringWorks**, rerun and the read operation functions correctly.