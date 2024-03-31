using LPlus;

namespace Tests;

[TestClass]
public class ConfigureFormatDateTimeTests
{
    [TestMethod]
    [DataRow("d", "1/2/2022")]
    [DataRow("MM/dd/yyyy", "01/02/2022")]
    [DataRow("dd.MM.yyyy", "02.01.2022")]
    [DataRow("HH:mm MM/dd/yyyy", "03:04 01/02/2022")]
    [DataRow("dd.MM.yyyy HH:mm", "02.01.2022 03:04")]
    public void ConfigureDateTime_WithVariable_StaticClassInvocation(
        string format,
        string expectedFormattedDateTime)
    {
        var dateTime = new DateTime(2022, 1, 2, 3, 4, 5);
        
        
        var formattedDateTime = TR.L + dateTime + format;
        
        
        Assert.AreEqual(expectedFormattedDateTime, formattedDateTime);
    }

    [TestMethod]
    [DataRow("d", "1/2/2022")]
    [DataRow("MM/dd/yyyy", "01/02/2022")]
    [DataRow("dd.MM.yyyy", "02.01.2022")]
    [DataRow("HH:mm MM/dd/yyyy", "03:04 01/02/2022")]
    [DataRow("dd.MM.yyyy HH:mm", "02.01.2022 03:04")]
    public void ConfigureDateTime_WithVariable_NewInstanceInvocation(
        string format,
        string expectedFormattedDateTime)
    {
        var dateTime = new DateTime(2022, 1, 2, 3, 4, 5);
        var l = new L();
        
        
        var formattedDateTime = l + dateTime + format;
        
        
        Assert.AreEqual(expectedFormattedDateTime, formattedDateTime);
    }
}