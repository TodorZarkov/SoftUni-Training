import { useContext, useEffect } from "react"
import { Link } from "react-router-dom"
import { UserContext } from "../../contexts/UserContext"

export const Logout = () => {
    
    const {onLogoutClick } = useContext(UserContext);

    useEffect(() => {
        onLogoutClick();
    }, [])

    return <Link to="/" />
}