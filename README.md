# VadzimStsiarzhanauTestTask

Hello, my name is Vadzim Stsiarzhanau and here you can find my test task for a QA Engineer position to Avanade in Kraków.

There were 3 tests required:
1. There is more than 5 results for Location: “Krakow”
2. There is at least 1 result for Location “Warsaw”
3. One of the qualifications for job offer: Location: ‘Seattle, Washington’/ ‘Entry Level Software Engineer, Seattle’ is: “Strong time management skills”

Currently, test #1 cannot pass, because there's exactly 5 results for Krakow, while test should verify that there's more than 5. 
Other 2 tests pass successfully.

To run the tests from command line, you have to:

1. Build the project in Visual Studio
2. Open cmd and change the directory to directory_where_you_have_my_project\packages\NUnit.ConsoleRunner.3.8.0\tools
3. Execute command  "nunit3-console.exe directory_where_you_have_my_project\VadzimStsiarzhanauTestTask\bin\Debug\VadzimStsiarzhanauTestTask.dll"

Thanks,
Vadzim
