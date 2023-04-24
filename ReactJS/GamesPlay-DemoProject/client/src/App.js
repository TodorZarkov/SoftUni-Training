import './App.css';
import { Routes, Route, useNavigate } from 'react-router-dom';

import { Catalog } from './components/Catalog/Catalog';
import { CreateGame } from './components/CreateGame/CreateGame';
import { Header } from './components/Header/Header';
import { Home } from './components/Home/Home';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register'
import { useEffect, useState } from 'react';
import { getAllGames, createGame } from './services/gameService';
import { GameDetails } from './components/GameDetails/GameDetails';


function App() {
  const navigate = useNavigate();

  const [games, setGames] = useState([]);

  useEffect(() => {
    getAllGames().then(result => setGames(result));
  }, []);

  const onCreateGameSubmit = async (data) => {
    const newGame = await createGame(data);
    console.log(newGame);
    setGames(state => ([...state, newGame]));
    navigate('/catalog')
  }

  return (
    <div id="box">
      <Header />
      <main id="main-content">
        <Routes >
          <Route path='/' element={<Home />} />
          <Route path='/login' element={<Login />} />
          <Route path='/register' element={<Register />} />
          <Route path='/create-game' element={<CreateGame onCreateGameSubmit={onCreateGameSubmit}/>} />
          <Route path='/catalog' element={<Catalog games={games}/>} />
          <Route path='/:gameId' element={<GameDetails/>} />

        </Routes>
      </main>
    </div>
  );
}

export default App;
