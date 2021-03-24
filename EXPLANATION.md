## Application Folder Structure

Application source code is available in folder - \eval-fast-bk-1-37dk\FortCode

Application unit tests are available in folder - \eval-fast-bk-1-37dk\FortCode.UnitTests

## Run the application unit tests as per below steps
Open command tool and navigate to the application source folder (val-fast-bk-1-37dk\FortCode.UnitTests) and execute below command
 
dotnet test

all the testcases will be executed and the result will be displayed.


## Run the application as per below steps
Open command tool and navigate to the application unit tests folder (\eval-fast-bk-1-37dk\FortCode) and execute below command
 
dotnet run

app will be up and running - listening on http://localhost:5000

Please go through the below steps for execution of this application( the api's are tested using postman)



## Register - User has to register with the application by providing username and password

HttpMethod: Post
URL - https://localhost:5000/api/user/register

	{        
        "name": "test",
        "password": "test",
		"email":"test@mail.com"
    }
Response : Success(200)

## Login - A registered user can login to the application by providing valid username and password and will receive token on successful login

HttpMethod: Post
URL - https://localhost:5000/api/user/login

	{      
        "name": "test",
        "password": "test"
    }
Response : "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJc3N1ZXIiOiJGb3J0Um9ib3RpY3MiLCJ1bmlxdWVfbmFtZSI6InRlc3F3dDIyIiwiZXhwIjoxNjE2MjYzNDE2LCJpc3
			MiOiJGb3J0Um9ib3RpY3MiLCJhdWQiOiJGb3J0Um9ib3RpY3MifQ.sLYjNbrTrDFikLTrctvK3PUmLXzU93uqJxyvaA-pGLs"
			
			
## Add Cities - A user with valid token can add city by invoking below api
HttpMethod: Post
URL - https://localhost:5000/api/city/add

	{        
        "cityname": "Hyderabad",
        "country": "India"
    }
Response : Success(200)


## Get Cities - A user with valid token can view all the cities by invoking below api
HttpMethod: Get
URL - https://localhost:5000/api/city
Response:

	{
        "id" : "1",
        "cityname": "Hyderabad",
        "country": "India"
    }
	

## Remove City - A user with valid token can remove the city by invoking below api
HttpMethod: Delete
URL - https://localhost:5000/api/city/1
Response : Success(200)