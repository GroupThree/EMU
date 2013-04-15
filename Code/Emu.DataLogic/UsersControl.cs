using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
	public class UsersControl : IUsersManager
	{
		#region Properties
		
		MySqlConnection Connection { get; set; }

		struct SQL
		{
			public const string GetAll = "select * from EmuUser";
			public const string GetByID = "select * from EmuUser where ID = @ID";
			public const string Create = "insert into EmuUser(Type, Username, Password) values (@Type, @Username, @Password)";
			public const string Update = "update EmuUser set Type = @Type, Username = @Username, Password = @Password where ID = @ID";
		}

		#endregion
		#region Constructor

		public UsersControl()
		{
			Connection = new MySqlConnection( "connection_string" ); 
		}

		#endregion
		#region Methods
		
		public List<User> Get()
		{
			var result = new List<User>();

			using (var cmd = new MySqlCommand(SQL.GetAll, Connection))
			{
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						// populate an equipment record
					}
				}
			}

			return result;
		}

		public User Get( int id )
		{
			#region Validate Arguments

			if (id.IsPositive() == false)
			{
				throw new ArgumentException("Barcode argument must be a positive integer.", "barcode");
			}

			#endregion

			User result = null;

			using (var cmd = new MySqlCommand(SQL.GetByID, Connection))
			{
				cmd.Parameters.AddWithValue("@ID", id);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						result = new User
						{
							ID = Convert.ToInt32(reader["ID"]),
							Type = Convert.ToInt32(reader["Type"].ToString()).ToEnum(UserType.BasicUser),
							UserName = reader["Username"].ToString(),
							PasswordHash = reader["Password"].ToString()
						};

						// populate the relationships of an Equipment record too
					}
				}
			}
			
			return result;
		}

		public void Create( User user )
		{
			#region Validate Arguments
			
			#endregion

			using (var cmd = new MySqlCommand(SQL.Create, Connection))
			{
				cmd.Parameters.AddWithValue("@ID", user.ID);
				cmd.Parameters.AddWithValue("@Type", user.Type);
				cmd.Parameters.AddWithValue("@Username", user.UserName);
				cmd.Parameters.AddWithValue("@Password", user.PasswordHash);

				// run the update statement
				cmd.ExecuteNonQuery();
			}

		}

		public void Update( User user )
		{
			#region Validate Arguments

			#endregion

			using (var cmd = new MySqlCommand(SQL.Update, Connection))
			{
				cmd.Parameters.AddWithValue("@ID", user.ID);
				cmd.Parameters.AddWithValue("@Type", user.Type);
				cmd.Parameters.AddWithValue("@Username", user.UserName);
				cmd.Parameters.AddWithValue("@Password", user.PasswordHash);

				// run the update statement
				cmd.ExecuteNonQuery();
			}

		}

		public User Authenticate( string userName, string password )
		{
			#region Validate Arguments

			#endregion

			User result = null;

			return result;
		}

		#endregion
	}
}
