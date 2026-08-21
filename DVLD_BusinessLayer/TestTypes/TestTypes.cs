using System.Data;
using System.Threading;

public class TestTypes
{
   public enum enTestTypes {Vision=1,Written=2,Street=3 };

    public TestTypes.enTestTypes ID { get; set; }
    public string TestTypeTitle { get; set; }
    public string TestTypeDescription { get; set; }
    public double TestTypeFees { get; set; }

    public TestTypes()
    {
        ID = enTestTypes.Vision;
        TestTypeTitle = string.Empty;
        TestTypeDescription = string.Empty;
        TestTypeFees = 0.0;
    }

    private TestTypes(enTestTypes testTypeID, string testTypeTitle, string testTypeDescription, double testTypeFees)
    {
        ID = testTypeID;
        TestTypeTitle = testTypeTitle;
        TestTypeDescription = testTypeDescription;
        TestTypeFees = testTypeFees;
    }

    public static TestTypes Find(enTestTypes testTypeID)
    {
        string title = string.Empty;
        string description = string.Empty;
        double fees = 0.0;

        if (TestTypesDataAccess.findTestType((int)testTypeID, ref title, ref description, ref fees))
        {
            return new TestTypes(testTypeID, title, description, fees);
        }

        return null;
    }

    public static bool isTestTypeExist(enTestTypes TestTypeID )
    {
        return TestTypesDataAccess.isTestTypeExistByID((int)TestTypeID);
    }
    public bool UpdateTestTypes()
    {
        return TestTypesDataAccess.UpdateApplicationType((int)this.ID,this.TestTypeTitle,this.TestTypeDescription,this.TestTypeFees);
    }

    public static DataTable getAllRecords()
    {
        return TestTypesDataAccess.getTestTypesRecords();
    }
}