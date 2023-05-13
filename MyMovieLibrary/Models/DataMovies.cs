namespace MyMovieLibrary.Models
{
    public struct DataMovies
    {
        public string Original_title { get; set; }
        public int Folder_id { get; set; }
        public string Overview { get; set; }
        public string Original_language { get; set; }
        public float Popularity { get; set; }
        public int Budget { get; set; }
        public string Release_date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public float Vote_average { get; set; }
        public int Vote_count { get; set; }
        public string Poster_path { get; set; }
        public string Backdrop_path { get; set; }
        public string Path { get; set; }
    }
}
