foreach(var rel in Model.Relationships) {
    
    rel.JoinOnDateBehavior = DateTimeRelationshipBehavior.DatePartOnly;
    
}