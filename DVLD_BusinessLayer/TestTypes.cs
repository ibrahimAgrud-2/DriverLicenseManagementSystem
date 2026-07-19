using System.Data;
using System.Threading;

public class clsTestType
{
   public enum enTestTypes {VisionTest=1,WrittenTest=2,StreetTest=3 };

    public clsTestType.enTestTypes ID { get; set; }
    public string TestTypeTitle { get; set; }
    public string TestTypeDescription { get; set; }
    public double TestTypeFees { get; set; }

    public clsTestType()
    {
        ID = enTestTypes.VisionTest;
        TestTypeTitle = string.Empty;
        TestTypeDescription = string.Empty;
        TestTypeFees = 0.0;
    }

    private clsTestType(enTestTypes testTypeID, string testTypeTitle, string testTypeDescription, double testTypeFees)
    {
        ID = testTypeID;
        TestTypeTitle = testTypeTitle;
        TestTypeDescription = testTypeDescription;
        TestTypeFees = testTypeFees;
    }

    public static clsTestType Find(enTestTypes testTypeID)
    {
        string title = string.Empty;
        string description = string.Empty;
        double fees = 0.0;

        if (TestTypesDataAccess.findTestType((int)testTypeID, ref title, ref description, ref fees))
        {
            return new clsTestType(testTypeID, title, description, fees);
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