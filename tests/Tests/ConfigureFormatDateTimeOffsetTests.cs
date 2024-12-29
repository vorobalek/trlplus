using LPlus;

namespace Tests;

[TestClass]
public class ConfigureFormatDateTimeOffsetTests
{
    [TestMethod]
    [DataRow("d", "1/2/2022")]
    [DataRow("MM/dd/yyyy", "01/02/2022")]
    [DataRow("MM/dd/yyyy K", "01/02/2022 +03:30")]
    [DataRow("MM/dd/yyyy zzz", "01/02/2022 +03:30")]
    [DataRow("dd.MM.yyyy", "02.01.2022")]
    [DataRow("dd.MM.yyyy K", "02.01.2022 +03:30")]
    [DataRow("dd.MM.yyyy zzz", "02.01.2022 +03:30")]
    [DataRow("HH:mm MM/dd/yyyy", "03:04 01/02/2022")]
    [DataRow("HH:mm MM/dd/yyyy K", "03:04 01/02/2022 +03:30")]
    [DataRow("HH:mm MM/dd/yyyy zzz", "03:04 01/02/2022 +03:30")]
    [DataRow("dd.MM.yyyy HH:mm", "02.01.2022 03:04")]
    [DataRow("dd.MM.yyyy HH:mm K", "02.01.2022 03:04 +03:30")]
    [DataRow("dd.MM.yyyy HH:mm zzz", "02.01.2022 03:04 +03:30")]
    public void ConfigureDateTimeOffset_WithVariable_StaticClassInvocation(
        string format,
        string expectedFormattedDateTimeOffset)
    {
        var dateTimeOffset = new DateTimeOffset(2022, 1, 2, 3, 4, 5, new TimeSpan(3, 30, 0));
        
        
        var formattedDateTimeOffset = TR.L + dateTimeOffset + format;
        
        
        Assert.AreEqual(expectedFormattedDateTimeOffset, formattedDateTimeOffset);
    }

    [TestMethod]
    [DataRow("d", "1/2/2022")]
    [DataRow("MM/dd/yyyy", "01/02/2022")]
    [DataRow("MM/dd/yyyy K", "01/02/2022 +03:30")]
    [DataRow("MM/dd/yyyy zzz", "01/02/2022 +03:30")]
    [DataRow("dd.MM.yyyy", "02.01.2022")]
    [DataRow("dd.MM.yyyy K", "02.01.2022 +03:30")]
    [DataRow("dd.MM.yyyy zzz", "02.01.2022 +03:30")]
    [DataRow("HH:mm MM/dd/yyyy", "03:04 01/02/2022")]
    [DataRow("HH:mm MM/dd/yyyy K", "03:04 01/02/2022 +03:30")]
    [DataRow("HH:mm MM/dd/yyyy zzz", "03:04 01/02/2022 +03:30")]
    [DataRow("dd.MM.yyyy HH:mm", "02.01.2022 03:04")]
    [DataRow("dd.MM.yyyy HH:mm K", "02.01.2022 03:04 +03:30")]
    [DataRow("dd.MM.yyyy HH:mm zzz", "02.01.2022 03:04 +03:30")]
    public void ConfigureDateTimeOffset_WithVariable_NewInstanceInvocation(
        string format,
        string expectedFormattedDateTimeOffset)
    {
        var dateTimeOffset = new DateTimeOffset(2022, 1, 2, 3, 4, 5, new TimeSpan(3, 30, 0));
        var l = new L();
        
        
        var formattedDateTimeOffset = l + dateTimeOffset + format;
        
        
        Assert.AreEqual(expectedFormattedDateTimeOffset, formattedDateTimeOffset);
    }
}