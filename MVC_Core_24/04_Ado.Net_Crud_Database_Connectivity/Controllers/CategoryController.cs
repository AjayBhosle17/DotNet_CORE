using _04_Ado.Net_Crud_Database_Connectivity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace _04_Ado.Net_Crud_Database_Connectivity.Controllers
{
    public class CategoryController : Controller
    {
        private readonly string cs;
        private readonly IConfiguration _config;
        private readonly ILogger<CategoryController> _logger;  

        // Constructor with Dependency Injection
        public CategoryController(IConfiguration config, ILogger<CategoryController> logger)
        {
            _config = config;
            _logger = logger;
            cs = _config.GetConnectionString("ADONetCS");  // Fetching connection string
        }

        // Display all categories

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string query = "SELECT * FROM Category";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Category obj = new Category()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Rating = (int)reader["Rating"]
                            };

                            categories.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Index method.");
                ViewBag.ErrorMessage = "Something went wrong while fetching categories.";
            }

            return View(categories);
        }

        //Display the Create form
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Insert a new category

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string query = "INSERT INTO Category (Name, Rating) VALUES (@Name, @Rating)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@Rating", category.Rating);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Create method.");
                ViewBag.ErrorMessage = "Something went wrong while adding the category. Please try again.";
                return View(category);
            }
        }

        [HttpGet]

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");  // Redirect if no ID is provided
            }

            Category category = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string query = "SELECT * FROM Category WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", id);  // ✅ Using parameterized query

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        category = new Category()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Rating = (int)reader["Rating"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Details method.");
                ViewBag.ErrorMessage = "Something went wrong while fetching category details.";
                return View("Error");  
            }

            if (category == null)
            {
                return NotFound();  
            }

            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int? id) { 
        
            Category category = null;

            using (SqlConnection conn = new SqlConnection(cs)) {

                string query = $"select * from Category where id = {id}";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read()) {

                    category = new Category()
                    {

                        Name = (string)reader["Name"],
                        Rating = (int)reader["Rating"]
                    };
                }


            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string query = $"UPDATE Category SET Name = '{category.Name}', Rating = {category.Rating} WHERE Id = {category.Id}";
                    SqlCommand cmd = new SqlCommand(query, conn);

                   /* cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@Rating", category.Rating);
                    cmd.Parameters.AddWithValue("@Id", category.Id);
*/
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return NotFound(); 
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Edit method.");
                ViewBag.ErrorMessage = "Something went wrong while updating the category.";
                return View(category);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id) {
            Category category = null;

            using (SqlConnection conn = new SqlConnection(cs))
            {

                string query = $"select * from Category where id = {id}";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.HasRows && reader.Read())
                {

                    category = new Category()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Rating = (int)reader["Rating"]
                    };
                }


            }
            return View(category);
        }

        [HttpPost]
        [ActionName("delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    /*string query = "DELETE FROM Category WHERE Id = @Id";*/

                    string query = $"delete from category where id = {id}";

                    SqlCommand cmd = new SqlCommand(query, conn);

                  //  cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Delete method.");
                ViewBag.ErrorMessage = "Something went wrong while deleting the category.";
                return View("Error");
            }
        }

    }

}
