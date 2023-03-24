import { useState } from "react";
import MovieList from "./components.js/MovieList";
import { movies  as movieData} from "./movies"

function App() {
  const [movies, setMovies] = useState(movieData);

  const onMovieDelete = (id) => {
    setMovies(state => state.filter(m => m.id !== id));
  }

  const onMovieSelect = (id) => {
    setMovies(state => state.map(x=> ({...x, selected: x.id === id})))
  }

  return (
    <div className="App">
      <h1>Movie Collection</h1>

      <MovieList 
        movies={movies} 
        onMovieDelete={onMovieDelete} 
        onMovieSelect={onMovieSelect}
      />

    </div>
  );
}

export default App;
