string tsv = "Measure\tDependsOnTable"; // TSV file header row

// Loop through all measures:
foreach(var m in Model.AllMeasures) {

    // Get a list of ALL objects referenced by this measure (both directly and indirectly through other measures):
    var allReferences = m.DependsOn.Deep();

    // Filter the previous list of references to table references only. For column references, let's get th
    // table that each column belongs to. Finally, keep only distinct tables:
    var allTableReferences = allReferences.OfType<Table>()
        .Concat(allReferences.OfType<Column>().Select(c => c.Table)).Distinct();

    // Output TSV rows - one for each table reference:
    foreach(var t in allTableReferences)
        tsv += string.Format("\r\n{0}\t{1}", m.Name, t.Name);
}
    
tsv.Output();   