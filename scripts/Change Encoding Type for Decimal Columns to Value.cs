foreach(var column in Model.Tables.SelectMany(t => t.Columns)) {
    
    if(column.DataType == DataType.Decimal)         
        column.EncodingHint = EncodingHintType.Value;
    
}