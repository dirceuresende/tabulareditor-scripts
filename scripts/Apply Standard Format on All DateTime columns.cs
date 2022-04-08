foreach(var column in Model.Tables.SelectMany(t => t.Columns)) {
    
    if(column.DataType == DataType.DateTime && column.FormatString != "dd/mm/yyyy")
        column.FormatString = "dd/MM/yyyy";
    
}