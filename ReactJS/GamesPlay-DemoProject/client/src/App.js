import './App.css';
import { Routes, Route } from 'react-router-dom';

import { Catalog } from './components/Catalog/Catalog';
import { CreateGame } from './components/CreateGame/CreateGame';
import { Header } from './components/Header/Header';
import { Home } from './components/Home/Home';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register'
import { GameDetails } from './components/GameDetails/GameDetails';

import { UserProvider } from './contexts/UserContext';

import { Logout } from './components/Logout/Logout';
import { EditGame } from './components/EditGame/EditGame';
import { DeleteGame } from './components/DeleteGame/DeleteGame';
import { GameProvider } from './contexts/GameContext';


function App() {



  return (
    <UserProvider>
      <GameProvider>
        <div id="box">
          <Header />

          <main id="main-content">
            <Routes >
              
              <Route path='/' element={<Home />} />
              <Route path='/login' element={<Login />} />
              <Route path='/register' element={<Register />} />
              <Route path='/logout' element={<Logout />} />
              <Route path='/create-game' element={<CreateGame />} />
              <Route path='/catalog' element={<Catalog />} />
              <Route path='/:gameId' element={<GameDetails />} />
              <Route path='/:gameId/edit-game' element={<EditGame />} />
              <Route path='/:gameId/delete-game' element={<DeleteGame />} />

            </Routes>
          </main>
        </div>
      </GameProvider>
    </UserProvider>
  );
}

export default App;
