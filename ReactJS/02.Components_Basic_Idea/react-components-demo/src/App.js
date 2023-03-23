import './App.css';
import Counter from './components/Counter';
import MovieList from './components/MovieList';
import Timer from './components/Timer';

function App() {
  const movies = [
    { title: "Man of Steal", year: "2008", cast: ["pencho", "trajcho", "karamfil"] },

    { title: "Haro Potter", year: "2010", cast: ["hari", "stamat", "pencho"] },

    { title: "Lord of the Rings", year: "2005", cast: ["pencho", "trajcho", "karamfil"] }
  ];

  return (
    <div className="App">

      <Counter canReset />
      <Timer start={0}/>

      <MovieList movies={movies} />
    </div>
  );
}

export default App;
