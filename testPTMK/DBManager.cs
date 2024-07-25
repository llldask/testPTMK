using Microsoft.Data.SqlClient;

namespace testPTMK
{
    public class DBManager
    {
        private static string connectionString = "Server=.\\SQLExpress;Database=test_db;Trusted_Connection=True;TrustServerCertificate=True;";
        private static string tableName = "Employee";
        public static void CreateNewTableEmployee()
        {
            string sqlExpression = string.Format("CREATE TABLE {0}(Id INT PRIMARY KEY IDENTITY(1,1),Name VARCHAR(50), DateOfBirth DATE,Gender VARCHAR(10))", tableName);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void AddNewEmployee(Employee employee)
        {
            string sqlExpression = string.Format("INSERT INTO {0} (Name, DateOfBirth, Gender) VALUES ('{1}', '{2}','{3}')",
                           tableName, employee.Name, employee.DateOfBirth.ToString("yyyyMMdd"), employee.Gender.ToString());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }

        }

        public static void AddArrayEmployees(Employee[] employees)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                for (int i = 0; i < employees.Length; i++)
                {
                    command.CommandText = string.Format("INSERT INTO {0} (Name, DateOfBirth, Gender) VALUES ('{1}', '{2}','{3}')",
                           tableName, employees[i].Name, employees[i].DateOfBirth.ToString("yyyyMMdd"), employees[i].Gender.ToString());
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
        }

        public static List<Employee> Select(string sqlExpression)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read()) 
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var date = reader.GetDateTime(2);
                        var gender = reader.GetString(3);

                        employees.Add(new Employee(id, name, date, gender));
                    }

                }
            }
            return employees;
        }

        public static List<Employee> Select1()
        {
            string sqlExpression = string.Format("SELECT * FROM {0} as e1 WHERE  1= (SELECT COUNT(*) FROM {0} as e2 WHERE e1.Name = e2.Name AND e1.DateOfBirth = e2.DateOfBirth) ORDER By e1.name;", tableName);
           return Select(sqlExpression);
        }

        public static List<Employee> Select2()
        {
            string sqlExpression = string.Format("SELECT * FROM {0} WHERE gender = 'Male' and name LIKE 'F%';", tableName);
            return Select(sqlExpression);
        }

    }
}