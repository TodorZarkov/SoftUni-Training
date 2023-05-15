import { createContext, useState } from "react"

import { userServiceFactory } from '../services/userService';
import { useNavigate } from "react-router-dom";



export const UserContext = createContext();


export const UserProvider = ({ children }) => {


    const navigate = useNavigate();

    const [user, setUser] = useState({});
    const userService = userServiceFactory(user.accessToken);

    const onLoginSubmit = async (values) => {
        try {
            const userData = await userService.onLogin(values);
            setUser(userData);

            navigate('/catalog')
        } catch (error) {
            // TODO: handle login error
            console.log(error)
        }
    };

    const onRegisterSubmit = async (values) => {
        if (values.password !== values.confirmPassword) {
            // TOTO: handle not confirmed password
            console.log("Wrong confirm password");
            return;
        }

        const { confirmPassword, ...registerData } = values;

        try {
            const userData = await userService.onRegister(registerData);
            setUser(userData);

            navigate('/catalog')
        } catch (error) {
            // TODO: handle register error
            console.log(error)
        }
    };

    const onLogoutClick = () => {
        setUser({});
        userService.onLogout();
    };

    const userVariables = {
        onLoginSubmit,
        onRegisterSubmit,
        onLogoutClick,
        userEmail: user.email,
        userId: user._id,
        token: user.accessToken,
        isLogged: !!user.accessToken,
    };

    return (
        <UserContext.Provider value={userVariables}>
            {children}
        </UserContext.Provider>
    );
};