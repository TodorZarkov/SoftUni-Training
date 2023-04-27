import { useContext } from "react";
import { useForm } from "../../hooks/useForm";
import { UserContext } from "../../contexts/UserContext";

export const Login = () => {
    const {onLoginSubmit} = useContext(UserContext);

    const names = {
        Email: 'email',
        Password: 'password',
    }

    const initialValues = {
        [names.Email]: '',
        [names.Password]: '',
    }

    const [values, onChange, onFormSubmit] = useForm(onLoginSubmit, initialValues)

    return (
        <section id="login-page" className="auth">
            <form id="login" onSubmit={onFormSubmit}>
                <div className="container">
                    <div className="brand-logo"></div>
                    <h1>Login</h1>
                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        placeholder="Sokka@gmail.com" 
                        value={values[names.Email]}
                        onChange={onChange}
                    />

                    <label htmlFor="login-pass">Password:</label>
                    <input
                        type="password"
                        id="login-password"
                        name="password" 
                        value={values[names.Password]}
                        onChange={onChange}
                    />
                    <input type="submit" className="btn submit" value="Login" />
                    <p className="field">
                        <span>If you don't have profile click <a href="#">here</a></span>
                    </p>
                </div>
            </form>
        </section>
    );
};