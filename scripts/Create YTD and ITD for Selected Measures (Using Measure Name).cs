// Creates a SUM measure for every currently selected column and hide the column.
foreach(var c in Selected.Measures)
{
    var newMeasure1 = c.Table.AddMeasure(
    c.Name + " (ITD)",                    // Name
        "VAR lastDay = MAX ( 'PostedDate'[DateKey] )\n\nRETURN\n    CALCULATE ( \n        " + c.DaxObjectFullName + ", \n        FILTER ( ALL ( 'PostedDate'[DateKey] ), 'PostedDate'[DateKey] <= lastDay )\n    )",    // DAX expression
        c.DisplayFolder                        // Display Folder
    );
    
    // Set the format string on the new measure:
    newMeasure1.FormatString = c.FormatString;

    // Provide some documentation:
    newMeasure1.Description = "This measure is the ITD (Inception To Date) by Value Date/PostedDate of measure " + c.DaxObjectFullName;
    
    
    
    var newMeasure2 = c.Table.AddMeasure(
        c.Name + " (YTD)",                    // Name
        "TOTALYTD ( " + c.DaxObjectFullName + ", 'PostedDate'[DateKey] )",    // DAX expression
        c.DisplayFolder                        // Display Folder
    );
    
    // Set the format string on the new measure:
    newMeasure2.FormatString = c.FormatString;

    // Provide some documentation:
    newMeasure2.Description = "This measure is the YTD (Year To Date) by Value Date/PostedDate of measure " + c.DaxObjectFullName;
    
    
    
    
    var newMeasure3 = c.Table.AddMeasure(
    c.Name + " (ITD by Fiscal Date)",                    // Name
        "VAR lastDay = MAX ( 'EffectiveDate'[DateKey] )\n\nRETURN\n    CALCULATE ( \n        " + c.DaxObjectFullName + ", \n        FILTER ( ALL ( 'EffectiveDate'[DateKey] ), 'EffectiveDate'[DateKey] <= lastDay )\n    )",    // DAX expression
        c.DisplayFolder                        // Display Folder
    );
    
    // Set the format string on the new measure:
    newMeasure3.FormatString = c.FormatString;

    // Provide some documentation:
    newMeasure3.Description = "This measure is the ITD (Inception To Date) by Fiscal Date/EffectiveDate of measure " + c.DaxObjectFullName;
    
    
    
    var newMeasure4 = c.Table.AddMeasure(
        c.Name + " (YTD by Fiscal Date)",                    // Name
        "TOTALYTD ( " + c.DaxObjectFullName + ", 'EffectiveDate'[DateKey] )",    // DAX expression
        c.DisplayFolder                        // Display Folder
    );
    
    // Set the format string on the new measure:
    newMeasure4.FormatString = c.FormatString;

    // Provide some documentation:
    newMeasure4.Description = "This measure is the YTD (Year To Date) by Fiscal Date/EffectiveDate of measure " + c.DaxObjectFullName;
    
}