create table Tip
(
	TipId int primary key identity,
	TipNaziv nvarchar(50) not null
);

create table Kategorija
(
	KategorijaId int primary key identity,
	KategorijaNaziv nvarchar(50) not null
);

create table Artikal
(
	ArtikalId int primary key identity,
	KategorijaId int foreign key references Kategorija(KategorijaId),
	TipId int foreign key references Tip(TipId),
	ArtikalNaziv nvarchar(100) not null,
	ArtikalOpis nvarchar(350) not null,
	ArtikalMarka nvarchar(50) not null,
	ArtikalCena float not null,
	ArtikalAkcija bit not null,
	ArtikalObrisan bit not null
);


