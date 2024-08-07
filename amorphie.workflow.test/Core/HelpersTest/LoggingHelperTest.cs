using amorphie.workflow.core.Logging;

namespace amorphie.workflow.test.core;
public class LoggingHelperTest
{

    [Fact]
    public void FilterResponseTest()
    {
        var jsonBody = "{\"access_token\":\"TestValue\",\"addressDetail\":\"no 11\",\"birthDate\":\"2003-08-04\",\"citizenshipNumber\":\"1234\",\"cityCode\":\"99\",\"cityName\":\"STANBUL\",\"courierVisitType\":\"1\",\"creditCardApplicationFlowStatus\":true,\"currentWorkTime\":{\"month\":8,\"year\":2021},\"districtCode\":\"123456\",\"districtName\":\"BURGAZADA MAH.\",\"educationType\":5,\"email\":\"du@gmail.com\",\"emailAddress\":\"du@gmail.com\",\"infoMessage\":null,\"isWorking\":true,\"marketingCommunicationPermitted\":false,\"marketingCommunicationVersionMajor\":\"WEB\",\"marketingCommunicationVersionMinor\":1,\"maskedPhoneNumber\":\"00*****000\",\"mobilePhoneNumber\":\"00\",\"monthlyIncome\":777777,\"operationCapacity\":2,\"operationCount\":2,\"organizationName\":\"Burgan Bank.  \",\"organizationSectorCode\":3,\"organizationSectorName\":\"Bili�im\",\"otp\":\"000\",\"ownerChannelCode\":\"MOBILUYGULAMA\",\"personalDataAgreementPermitted\":true,\"personalDataAgreementVersionMajor\":\"WEB\",\"personalDataAgreementVersionMinor\":1,\"preferredProductTypes\":\"1,3,5\",\"processId\":\"f7687b65-485d-459d-90db-fc57f3b1142a\",\"professionId\":65,\"refresh_token\":\"Test_Refresh\",\"residenceType\":1,\"showProductInSms\":true,\"sourcesOfIncome\":\"3,2\",\"streetCode\":\"195469\",\"streetName\":\"SK.\",\"townCode\":\"1103\",\"townName\":\"ADALAR\",\"workflowFormKeyStatusCode\":\"200\",\"workflowFormKeyStatusMessage\":\"\",\"workingType\":1,\"approveMessages\":[{\"Id\":1,\"Name\":\"A\"},{\"Id\":2,\"Name\":\"T\"},{\"Id\":3,\"Name\":\"A\"}],\"usConnection\":false,\"usConnectionselectedOption\":1,\"selectedOptionTitle\":\"general_no_button\",\"taxPayerType\":10,\"taxPayerTypeselectedOption\":1,\"documents\":[{\"id\":\"3cbd1de0-5b06-4b12-adb9-0a05be3a21c5\",\"actionType\":\"20\",\"actionDate\":\"2024-08-04T21:45:28.588533+03:00\",\"itemIdentifierKey\":\"3\"},{\"id\":\"8\",\"actionType\":\"20\",\"actionDate\":\"2024-08-04T21:45:34.928504+03:00\",\"itemIdentifierKey\":\"8\"},{\"id\":\"b\",\"actionType\":\"40\",\"actionDate\":\"2024-08-04T21:45:11.255321+03:00\",\"itemIdentifierKey\":\"b\"}]}";
        string[] redactedResponse = ["access_token", "refresh_token", "client_secret", "x-userinfo", "authorization"];

        var decryptResult = LoggingHelper.FilterResponse(jsonBody, redactedResponse);
    }

}
