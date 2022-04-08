foreach(var column in Model.Tables.SelectMany(t => t.Columns)) 
{
    
    if(column.IsHidden) {
        column.IsAvailableInMDX = false;
    }
    else if ( ( column.DataType == DataType.Decimal || column.DataType == DataType.Double || column.DataType == DataType.Int64 ) && column.SummarizeBy != AggregateFunction.None ) {
        column.IsAvailableInMDX = false;
    }
    else {
        column.IsAvailableInMDX = true;
    }
    
}