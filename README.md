# Accelerex
This repo is for the Accelerex assessment test.

Installation guides
Clone the App

run dotnet restore to install dependencies.

The API documentation lives here `https://localhost:7000/swagger/index.html`

There are 2 endpoints, one for each question. Also a test was written for the second question.

To test the first endpoint api/convert, the endpoint requires the input be assigned to the variable 'days'
Example payload is in path: Accelerex.Domain/testdata.json

Question 1 also asks to tell my thoughts on the json payload

The JSON payload form is good, only subjective preference for me would be to get the day as a value as well. 

{
  {
    {
      "day": "Monday",
      "values": [
        {
          "type": "close",
          "value""3600"
        },
        {
          "type": "close",
          "value""43200"
        }
      }
    }
  }
