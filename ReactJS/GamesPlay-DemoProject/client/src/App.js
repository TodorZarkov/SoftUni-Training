import './App.css';
import { Routes, Route, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';

import { Catalog } from './components/Catalog/Catalog';
import { CreateGame } from './components/CreateGame/CreateGame';
import { Header } from './components/Header/Header';
import { Home } from './components/Home/Home';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register'

import { gameServiceFactory } from './services/gameService';
import { GameDetails } from './components/GameDetails/GameDetails';

import { UserContext, UserProvider } from './contexts/UserContext';
import { Logout } from './components/Logout/Logout';
import { EditGame } from './components/EditGame/EditGame';
import { DeleteGame } from './components/DeleteGame/DeleteGame';


function App() {

  const navigate = useNavigate();

  const [games, setGames] = useState([]);
  const gameService = gameServiceFactory("");//user.accessToken);


  useEffect(() => {
    gameService.getAll().then(result => setGames(result));
  }, []);

  const onCreateGameSubmit = async (data) => {
    const newGame = await gameService.create(data);
    setGames(state => ([...state, newGame]));
    navigate('/catalog')
  };

  const onEditGameSubmit = async (data) => {
    const { _id, ...gameData } = data;
    const editedGame = await gameService.update(_id, gameData);
    setGames(state => state.map(g => g._id === _id ? editedGame : g));
    navigate(`/${data._id}`)
  };

  const onDeleteGameClick = (gameId) => {
    gameService.remove(gameId)
      .then(setGames(state => state.filter(g => g._id!==gameId)));
      // TODO: catch if server not responging!
  };

  return (
    <UserProvider>
      <div id="box">
        <Header />
        
        <main id="main-content">
          <Routes >
            <Route path='/' element={<Home />} />
            <Route path='/login' element={<Login />} />
            <Route path='/register' element={<Register />} />
            <Route path='/logout' element={<Logout />} />
            <Route path='/create-game' element={<CreateGame onCreateGameSubmit={onCreateGameSubmit} />} />
            <Route path='/catalog' element={<Catalog games={games} />} />
            <Route path='/:gameId' element={<GameDetails />} />
            <Route path='/:gameId/edit-game' element={<EditGame onEditGameSubmit={onEditGameSubmit} />} />
            <Route path='/:gameId/delete-game' element={<DeleteGame onDeleteGameClick={onDeleteGameClick} />} />

          </Routes>
        </main>
      </div>
    </UserProvider>
  );
}

export default App;
