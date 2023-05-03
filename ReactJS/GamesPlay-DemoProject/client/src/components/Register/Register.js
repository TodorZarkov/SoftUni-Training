import { useContext } from "react";
import { UserContext } from "../../contexts/UserContext";
import { useForm } from "../../hooks/useForm";
import { Link } from "react-router-dom";

export const Register = () => {
    const {onRegisterSubmit} = useContext(UserContext);

    const names = {
        Email :'email',
        Password :'password',
        ConfirmPassword :'confirmPassword',
    }

    const initialValues = {
        [names.Email] :'',
        [names.Password] :'',
        [names.ConfirmPassword] :'',

    }

    const [values, onClickHandler, onFormSubmit] = useForm(onRegisterSubmit, initialValues);

    return (
        <section id="register-page" className="content auth">
            <form id="register" onSubmit={onFormSubmit}>
                <div className="container">
                    <div className="brand-logo"></div>
                    <h1>Register</h1>

                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        placeholder="maria@email.com"
                        value={values[names.Email]}
                        onChange={onClickHandler}
                    />

                    <label htmlFor="pass">Password:</label>
                    <input
                        type="password"
                        name="password"
                        id="register-password" 
                        value={values[names.Password]}
                        onChange={onClickHandler}
                    />

                    <label htmlFor="con-pass">Confirm Password:</label>
                    <input
                        type="password"
                        name="confirmPassword"
                        id="confirm-password" 
                        value={values[names.ConfirmPassword]}
                        onChange={onClickHandler}
                    />

                    <input className="btn submit" type="submit" value="Register" />

                    <p className="field">
                        <span>If you already have profile click <Link to={'/login'}>here</Link></span>
                    </p>
                </div>
            </form>
        </section>
    );
};