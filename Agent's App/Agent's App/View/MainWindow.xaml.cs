using Agent_s_App.Core.Model;
using Agent_s_App.Persistance;
using Agent_s_App.Persistance.Repository;
using Agent_s_App.ViewModel;
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
		public static AgentsAppContext context = new AgentsAppContext();
		public UnitOfWork unitOfWork = new UnitOfWork(context);

		public MainWindow()
		{
			#region address
			Address address1 = new Address()
			{
				Id = 55,
				Country = "Serbia",
				City = "Novi Sad",
				PostalCode = 21000,
				Street = "Laze Kositca",
				Number = "3",
				ApartmentNumber = "10"
			};

			Address address2 = new Address()
			{
				Id = 155,
				Country = "Serbia",
				City = "Novi Sad",
				PostalCode = 21000,
				Street = "Boska Buhe",
				Number = "6",
				ApartmentNumber = "11"
			};

			Address address3 = new Address()
			{
				Id = 51523,
				Country = "Bosnia and Herzegovina",
				City = "Bijeljina",
				PostalCode = 78316,
				Street = "Cengic",
				Number = "28",
			};

			Address address4 = new Address()
			{
				Id = 55124,
				Country = "Norway",
				City = "Oslo",
				PostalCode = 112000,
				Street = "Nicola Copernicus",
				Number = "3",
				ApartmentNumber = "10"
			};

			unitOfWork.Addresses.Add(address1);
			unitOfWork.Addresses.Add(address2);
			unitOfWork.Addresses.Add(address3);
			unitOfWork.Addresses.Add(address4);
			#endregion

			#region accommodation unit type
			AccommodationUnitType accommodationUnitType = new AccommodationUnitType()
			{
				Id = 5,
				Name = "Jednokrevetna",
				Deleted = false
			};

			AccommodationUnitType accommodationUnitType1 = new AccommodationUnitType()
			{
				Id = 124312,
				Name = "Dvokrevetna",
				Deleted = false
			};
			unitOfWork.AccommodationUnitTypes.Add(accommodationUnitType);
			unitOfWork.AccommodationUnitTypes.Add(accommodationUnitType1);


			#endregion

			#region service
			AccommodationService service = new AccommodationService()
			{
				Id = 412312,
				Name = "Sauna",
				Description = "Najmodernija sauna.",
			};

			unitOfWork.AccommodationServices.Add(service);
			#endregion

			#region accommodation
			Accommodation accommodation = new Accommodation()
			{
				Id = 6542,
				Name = "Hotel Park",
				Address = address1,
				Description = "Hotel u Novom Sadu sa 5 zvezdica.",
				AccommodationType = AccommodationType.HOTEL,
				Category = "5 zvezdica",
				Services = new List<AccommodationService>()
			};

			accommodation.Services.Add(service);

			unitOfWork.Accommodations.Add(accommodation);

			#endregion

			#region accommodation unit
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

			unitOfWork.AccommodationUnits.Add(accommodationUnit1);

			#endregion

			#region user
			User user1 = new User()
			{
				Id = 1230,
				Username = "draganjovic96",
				Name = "Dragan",
				LastName = "Jovic",
				Password = "12345678",
				Role = UserRole.AGENT,
				Address = address2,
				AgentOfAccommodation = accommodation
			};

			User user2 = new User()
			{
				Id = 1224717,
				Username = "cicann",
				Name = "Cican",
				LastName = "Obrenovic",
				Password = "12345678",
				Role = UserRole.AGENT,
				Address = address3,
				AgentOfAccommodation = accommodation
			};

			User user3 = new User()
			{
				Id = 718739,
				Username = "zivica",
				Name = "Jovica",
				LastName = "Zivanovic",
				Password = "12345678",
				Role = UserRole.REGISTERED_USER,
				Address = address4,
			};

			unitOfWork.Users.Add(user1);
			unitOfWork.Users.Add(user2);
			unitOfWork.Users.Add(user3);

			#endregion

			#region period price
			PeriodPrice periodPrice = new PeriodPrice()
			{
				Id = 123941,
				AccommodationUnit = accommodationUnit1,
				Price = 44.99,
				FromDate = new DateTime(2011, 6, 1),
				ToDate = new DateTime(2011, 7, 31)
			};

			unitOfWork.PeriodPrices.Add(periodPrice);
			#endregion

			#region comment rate
			CommentRate commentRate = new CommentRate()
			{
				Id = 132141,
				CommentDateTime = new DateTime(2019, 11, 13, 21, 21, 21),
				ApprovedComment = true,
				ContentOfComment = "Svaka cast!",
				Ocena = 5
			};

			unitOfWork.CommentRates.Add(commentRate);
			#endregion

			#region reservation
			Reservation reservation = new Reservation()
			{
				Id = 4234,
				AccommodationUnit = accommodationUnit1,
				Guest = user3,
				FromDate = new DateTime(2017, 10, 10),
				ToDate = new DateTime(2017, 10, 13),
				AgentConfirmed = true,
				Confirmed = true,
				CommentRate = commentRate
			};

			unitOfWork.Reservations.Add(reservation);

			#endregion

			#region message

			Message message = new Message()
			{
				Id = 413,
				Accommodation = accommodation,
				Sender = user3,
				Receiver = user1,
				MessageContent = "Pozdrav!",
				DatumVreme = new DateTime(2018, 12, 21, 15, 24, 12),
				Reservation = reservation,
				Seen = true
			};

			unitOfWork.Messages.Add(message);
			#endregion

			
			unitOfWork.Complete();


			InitializeComponent();
			DataContext = new MainViewModel();

		}
	}
}
