foreach(var obj in Selected.Measures)
{
        
    if (obj.DataType == DataType.Double || obj.DataType == DataType.Decimal) 
    {
        obj.FormatString = "$#,##0.00;-$#,##0.00";
    }

}

foreach(var obj in Selected.Columns)
{
        
    if (obj.DataType == DataType.Double || obj.DataType == DataType.Decimal) 
    {
        obj.FormatString = "$#,##0.00;-$#,##0.00";
    }

}
