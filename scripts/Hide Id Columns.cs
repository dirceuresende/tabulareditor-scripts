foreach(var obj in Model.Tables.SelectMany(t => t.Columns)) {
    
    var coluna = obj.Name;
    
    if (coluna.EndsWith("SK") || coluna.EndsWith("Id")) {
        if (coluna.Length > 2) {
            obj.IsHidden = true;
        }
    }
    
}
