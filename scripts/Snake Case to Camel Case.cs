foreach(var obj in Model.Tables.SelectMany(t => t.Columns)) {
    
    var oldName = obj.Name;
    var newName = new System.Text.StringBuilder();
    
    for(int i = 0; i < oldName.Length; i++) {
        
        // First letter should always be capitalized:
        if(i == 0) {
            newName.Append(Char.ToUpper(oldName[i]));
        }
        else if(oldName[i - 1] == '_')
        {
            newName.Append(char.ToUpper(oldName[i]));
        }
        else
        {
            newName.Append(char.ToLower(oldName[i]));
        }
    }
    
    obj.Name = newName.Replace("cao", "ção").Replace("_", " ").ToString();
    
}



foreach (var obj in Model.Tables) 
{
    
    var oldName = obj.Name;
    var newName = new System.Text.StringBuilder();
    
    for(int i = 0; i < oldName.Length; i++) {
        
        // First letter should always be capitalized:
        if(i == 0) {
            newName.Append(Char.ToUpper(oldName[i]));
        }
        else if(oldName[i - 1] == '_')
        {
            newName.Append(char.ToUpper(oldName[i]));
        }
        else
        {
            newName.Append(char.ToLower(oldName[i]));
        }
    }
    
    obj.Name = newName.Replace("cao", "ção").Replace("_", " ").ToString();
    
}
