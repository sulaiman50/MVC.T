using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoviesProject.Constants
{
    public class Queries
    {
        #region Movies Query
        public const string SelectAllMoviesQuery = "select * from Movies where isDeleted = 0";
        public const string SelectMovieByIdQuery = "select * from Movies where isDeleted = 0 AND id =@id;";
        public const string UpdateMovieQuery = "update Movies set Name = @Name, Description= @Description, Publish_Date = @Publish_date , creation_date = @creation_date where isDeleted = 0 AND id = @id;";
        public const string InsertMovieQuery = "insert into Movies(Name, Description,Publish_date,Director_Id,Rating_Id, creation_date, isDeleted) values(@Name,@Description,@Publish_date,@Director_Id,@Rating_Id,@creation_date,@isDeleted);";
        public const string DeleteMovieQuery = "update Movies set isDeleted = @isdeleted where id = @id;";
        #endregion

        #region Directors Query
        public const string SelectAllDirectorsQuery = "select * from Directors where isDeleted = 0";
        public const string SelectDirectorByIdQuery = "select * from Directors where isDeleted = 0 AND id =@id;";
        public const string UpdateDirectorQuery = "update Directors set Name = @Name, creation_date = @creation_date where isDeleted = 0 AND id = @id;";
        public const string InsertDirectorQuery = "insert into Directors(Name, creation_date, isDeleted) values(@Name,@creation_date,@isDeleted);";
        public const string DeleteDirectorQuery = "update Directors set isDeleted = @isdeleted where id = @id;";
        #endregion

        #region Ratings Query
        public const string SelectAllRatingsQuery = "select * from Ratings where isDeleted = 0";
        public const string SelectRatingByIdQuery = "select * from Ratings where isDeleted = 0 AND id =@id;";
        public const string UpdateRatingQuery = "update Ratings set Name = @Name, creation_date = @creation_date where isDeleted = 0 AND id = @id;";
        public const string InsertRatingQuery = "insert into Ratings(Name, creation_date, isDeleted) values(@Name,@creation_date,@isDeleted);";
        public const string DeleteRatingQuery = "update Ratings set isDeleted = @isdeleted where id = @id;";
        #endregion
    }
}
