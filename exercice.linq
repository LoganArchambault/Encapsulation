<Query Kind="Statements">
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
</Query>


		var rect = new Employé(1, "Archambault", "Logan", new DateTime(2010, 1, 20));
		int annéeAncienneté = 0;
		rect.CalculerAncienneté(rect.DateEmbauche, ref annéeAncienneté);
		rect.AfficherInfo(ref annéeAncienneté);
	







class Employé
{
	private int _id;
	private string _nom;
	private string _prénom;
	private DateTime _dateEmbauche;
	
	public Employé(int id, string nom, string prénom, DateTime dateEmbauche)
	{
		SetId(id);
		SetNom(nom);
		SetPrénom(prénom);
		SetDateEmbauche(dateEmbauche);
	}

	public int Id => _id;
	public string Nom => _nom;
	public string Prénom => _prénom;
	public DateTime DateEmbauche => _dateEmbauche;
	
	
	

    public void SetId(int id)
	{
		if(id <= 0)
		throw new ArgumentException();
		_id = id;
	}
	
	[MemberNotNull(nameof(_nom))]
	public void SetNom(string nom)
	{
		if(string.IsNullOrWhiteSpace(nom))
		throw new ArgumentException();
		_nom = nom;
	}
	[MemberNotNull(nameof(_prénom))]
	public void SetPrénom(string prénom)
	{
		if (string.IsNullOrWhiteSpace(prénom))
			throw new ArgumentException();
		_prénom = prénom;
	}
	public void SetDateEmbauche(DateTime dateEmbauche)
	{
		_dateEmbauche = dateEmbauche;
	}

	public int CalculerAncienneté(DateTime dateEmbauche, ref int annéeAncienneté)
	{
		int annéeLive = DateTime.Today.Year;
		int annéeEmbauche = dateEmbauche.Year;
	    annéeAncienneté = annéeLive - annéeEmbauche;
		return annéeAncienneté;
	}
	
	public void AfficherInfo(ref int annéeAncienneté)
	{
		string id = Id.ToString();
		string embauche = DateEmbauche.ToString();
		string ancienneté = annéeAncienneté.ToString();
		List <string> information = new();
		information.Add(id);
		information.Add(Nom);
		information.Add(Prénom);
		information.Add(embauche);
		information.Add(ancienneté);
		information.Dump();
	}

}
