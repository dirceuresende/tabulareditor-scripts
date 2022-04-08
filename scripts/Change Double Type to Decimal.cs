foreach(var column in Model.Tables.SelectMany(t => t.Columns)) {
    
    if(column.DataType == DataType.Double)         
        column.DataType = DataType.Decimal;
    
}