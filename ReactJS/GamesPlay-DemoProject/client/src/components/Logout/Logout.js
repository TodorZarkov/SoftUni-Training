import { useContext, useEffect } from "react"
import { Navigate } from "react-router-dom"
import { UserContext } from "../../contexts/UserContext"

export const Logout = () => {
    
    const {onLogoutClick } = useContext(UserContext);

    useEffect(() => {
        onLogoutClick();
    }, []);

    return <Navigate to="/" />
}