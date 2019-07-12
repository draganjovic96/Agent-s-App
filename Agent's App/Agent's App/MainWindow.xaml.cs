using Agent_s_App.Core.Model;
using Agent_s_App.Persistance;
using Agent_s_App.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agent_s_App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public UnitOfWork unitOfWork = new UnitOfWork(new AgentsAppContext());

		public MainWindow()
		{
			Address address = new Address()
			{
				Id = 55,
				Country = "Serbia",
				City = "Novi Sad",
				PostalCode = 21000,
				Street = "Laze Kositca",
				Number = "3",
				ApartmentNumber = "10"
			};

			AccommodationUnitType accommodationUnitType = new AccommodationUnitType()
			{
				Id = 5,
				Name = "Jednokrevetna",
				Deleted = false
			};

			Accommodation accommodation = new Accommodation()
			{
				Id = 6542,
				Name = "Hotel Park",
				Address = address,
				Description = "Hotel u Novom Sadu sa 5 zvezdica.",
				AccommodationType = AccommodationType.HOTEL,
				Category = "5 zvezdica",
			};

			AccommodationUnit accommodationUnit1 = new AccommodationUnit()
			{
				Id = 5123,
				Floor = 1,
				Number = "A1",
				AccommodationUnitType = accommodationUnitType,
				Accommodation = accommodation,
				NumberOfBeds = 1,
				DefaultPrice = 39.99
			};

			User user = new User()
			{
				Id = 1230,
				Username = "draganjovic96",
				Name = "Dragan",
				LastName = "Jovic",
				Password = "12345678",
				Role = UserRole.AGENT,
				Address = address,
				AgentOfAccommodation = accommodation
			};

			unitOfWork.Addresses.Add(address);
			unitOfWork.Users.Add(user);
			unitOfWork.Accommodations.Add(accommodation);
			unitOfWork.AccommodationUnitTypes.Add(accommodationUnitType);
			unitOfWork.AccommodationUnits.Add(accommodationUnit1);
			unitOfWork.Complete();



			InitializeComponent();
		}
	}
}
