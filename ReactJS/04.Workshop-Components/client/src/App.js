import './App.css';
import Header from './components/Header';
import Users from './components/Users';
import Details from './components/Details';
import CreateEdit from './components/CreateEdit';
import Delete from './components/Delete';
import Footer from './components/Footer';
import * as userService from './components/services/userService' ;
import {useEffect, useState} from 'react'

function App() {

  const [users, setUsers] = useState([]);

  const [isInfo,  setIsInfo] = useState(false);

  const [currentUser, setCurrentUser] = useState(null);

  const [isRemoveClicked, setIsRemoveClicked] = useState(false);

  const [currentId, setCurrentId] = useState(null);

  const [isCreateEdit, setIsCreateEdit] = useState(false);
  
  useEffect(() => {
    async function setData() {
      const data = await userService.getAll();
      setUsers(data.users);
    };
    setData();
  }, []);

  function onClose(){
    setIsInfo(()=>false);
    setIsRemoveClicked(()=>false);
    setIsCreateEdit(()=>false);

    setCurrentUser(()=>null);
  }

  async function onInfoClick(id) {
    const userInfo = await userService.getInfo(id);
    setCurrentUser(()=>userInfo);
    
    setIsInfo(()=>true);
  }

  function onRemoveClick(id) {
    setCurrentId(()=>id);
    setIsRemoveClicked(()=>true);
  }

  async function removeUser() {
    await userService.deleteUser(currentId);
    setUsers((state)=>state.filter(u => u._id !== currentId));
    setCurrentId(()=>null);
    
    onClose();
  }

  async function onEditClick(id) {
    const userInfo = await userService.getInfo(id);
    setCurrentUser(()=>userInfo);
    
    setIsCreateEdit(() => true);
  }

  async function onEditCreate(e, id) {
    e.preventDefault();
    
    const formData = new FormData(e.currentTarget);
    const data = Object.fromEntries(formData);

    if(id) {
      const user = await userService.update(id, data);
      setUsers((state)=>{
        return state.map(u => (u._id === user._id ? user : u));
      });
    } else {
      const user = await userService.create(data);
      setUsers((state) => [...state, user]);
    }

    

    onClose();
    setCurrentUser(()=>null);
  }

  function onCreateClick() {
    setIsCreateEdit(()=>true)
  }

  return (  
    <>
      <Header />

      <main className="main">


        <Users  users={users}
                onInfoClick={onInfoClick}
                onRemoveClick={onRemoveClick}
                onEditClick={onEditClick}
                onCreateClick={onCreateClick}
        />

        {isInfo && <Details onClose={onClose}
                            {...currentUser}
                /> }

        {isCreateEdit && <CreateEdit onClose={onClose}
                                    {...currentUser}
                                    onEditCreate={onEditCreate}
                        />}

        {isRemoveClicked && <Delete onClose={onClose}
                                    removeUser={removeUser}
                            />}

      </main>

      <Footer />
    </>
  );
}

export default App;
