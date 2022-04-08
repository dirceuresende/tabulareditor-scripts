var availableCustomFormatsFolder = new List<string>() {"FiscalMMYYYY", "FullDate", "MMYYYY", "FullDateDesc"};
var availableDaysFolder = new List<string>() {"DayName", "DayOfMonth", "DayOfQuarter", "DayOfWeek", "DayOfWeekInMonth", "DayOfWeekInYear", "DayOfYear", "DaySuffix", "FiscalDayOfYear"};
var availableFirstAndLastDaysFolder = new List<string>() {"FirstDayOfMonth", "FirstDayOfQuarter", "FirstDayOfYear", "FiscalFirstDayOfMonth", "FiscalFirstDayOfQuarter", "FiscalFirstDayOfYear", "FiscalLastDayOfMonth", "FiscalLastDayOfQuarter", "FiscalDayOfYear", "FiscalLastDayOfYear", "LastDayOfMonth", "LastDayOfQuarter", "LastDayOfYear"};
var availableMonthsFolder = new List<string>() {"FiscalMonth", "FiscalMonthYear", "Month", "MonthName", "MonthOfQuarter", "MonthYear"};
var availableQuarterFolder = new List<string>() {"FiscalQuarter", "FiscalQuarterName", "Quarter", "QuarterName"};
var availableWeeksFolder = new List<string>() {"FiscalWeekOfYear", "WeekOfMonth", "WeekOfQuarter", "WeekOfYear"};
var availableHolidaysFolder = new List<string>() {"HolidayNameinUSA", "IsHolidayinUSA", "HolidayUSA", "IsHolidayUSA", "IsWeekday"};
var availableYearsFolder = new List<string>() {"FiscalYear", "FiscalYearName", "Year", "YearName"};

foreach(var column in Selected.Tables.SelectMany(t => t.Columns)) 
{
    
    var name = column.Name;
    var camelCaseName = name.Replace(" ", "");
    
    // Apply default mask for Date/Datetime Fields
    if (column.DataType == DataType.DateTime && column.FormatString != "dd/MM/yyyy") {
        column.FormatString = "dd/MM/yyyy";
    }
    
    if (camelCaseName == "DateKey" || column.IsKey == true) {
        column.DisplayFolder = "Custom Formats";
        column.DataType = DataType.DateTime;
    }
    else if (availableCustomFormatsFolder.Contains(camelCaseName)) {
        column.DisplayFolder = "Custom Formats";

        if (camelCaseName == "FullDateDesc") {
            column.SortByColumn = column.Table.Columns["Date Key"];
        }

    }
    else if (availableDaysFolder.Contains(camelCaseName)) {
        
        column.DisplayFolder = "Days";
        
        if (camelCaseName == "DayName") {
            column.SortByColumn = column.Table.Columns["Day Of Week"];
        }
        
        if (camelCaseName == "DaySuffix") {
            column.SortByColumn = column.Table.Columns["Day Of Month"];
        }
        
    }
    else if (availableFirstAndLastDaysFolder.Contains(camelCaseName)) {
        column.DisplayFolder = "First and Last Days";
        column.FormatString = "General Date";
    }
    else if (availableMonthsFolder.Contains(camelCaseName)) {
        
        column.DisplayFolder = "Months";
        
        if (camelCaseName == "FiscalMonthYear") {
            column.SortByColumn = column.Table.Columns["Fiscal MMYYYY"];
        }
        
        if (camelCaseName == "MonthName") {
            column.SortByColumn = column.Table.Columns["Month"];
        }
    
        if (camelCaseName == "MonthYear") {
            column.SortByColumn = column.Table.Columns["MMYYYY"];
        }
        
    }
    else if (availableQuarterFolder.Contains(camelCaseName)) {
        
        column.DisplayFolder = "Quarters";
        
        if (camelCaseName == "FiscalQuarterName") {
            column.SortByColumn = column.Table.Columns["Fiscal Quarter"];
        }
        
        if (camelCaseName == "QuarterName") {
            column.SortByColumn = column.Table.Columns["Quarter"];
        }
    
    }
    else if (availableWeeksFolder.Contains(camelCaseName)) {
        column.DisplayFolder = "Weeks";
    }
    else if (availableHolidaysFolder.Contains(camelCaseName)) {
        column.DisplayFolder = "Working Days";
    }
    else if (availableYearsFolder.Contains(camelCaseName)) {
        
        column.DisplayFolder = "Years";
        
        if (camelCaseName == "FiscalYearName") {
            column.SortByColumn = column.Table.Columns["Fiscal Year"];
        }
        
        if (camelCaseName == "YearName") {
            column.SortByColumn = column.Table.Columns["Year"];
        }
    
    }
    
    
    //Apply Camel Case on Column Name
    var oldName = column.Name;
    var newName = new System.Text.StringBuilder();
    
    for(int i = 0; i < oldName.Length; i++) {
        
        // First letter should always be capitalized:
        if(i == 0) newName.Append(Char.ToUpper(oldName[i]));

        // A sequence of two uppercase letters followed by a lowercase letter should have a space inserted
        // after the first letter:
        else if(i + 2 < oldName.Length && char.IsLower(oldName[i + 2]) && char.IsUpper(oldName[i + 1]) && char.IsUpper(oldName[i]))
        {
            newName.Append(oldName[i]);
            newName.Append(" ");
        }

        // All other sequences of a lowercase letter followed by an uppercase letter, should have a space
        // inserted after the first letter:
        else if(i + 1 < oldName.Length && char.IsLower(oldName[i]) && char.IsUpper(oldName[i+1]))
        {
            newName.Append(oldName[i]);
            newName.Append(" ");
        }
        else
        {
            newName.Append(oldName[i]);
        }
    }
    
    column.Name = newName.ToString();
    
}


// Create Date Hierarchy
var selectedTable = Selected.Table.Name;
if (!Model.Tables[selectedTable].Hierarchies.Contains("Date Hierarchy")) {
    
    var h = Model.Tables[selectedTable].AddHierarchy("Date Hierarchy");
    
    h.AddLevel("Year");
    h.AddLevel("Month Name");
    h.AddLevel("Day Of Month");
    h.DisplayFolder = "Custom Formats";
}
