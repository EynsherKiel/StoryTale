import * as React from 'react'; 
import {
    BrowserRouter as Router,
    Switch,
    Route,
    NavLink 
} from "react-router-dom";
import { Flow } from './Graph/Flow';
import style from "./App.module.css"

const App: React.FC = () => (
    <Router>
        <div className={style.wrapper}> 

            <header className={style.header}>
                <nav className={style.navbar}>
                    <NavLink exact className={style.navLink} activeClassName={style.navLinkActive} to="/">Home</NavLink>
                    <NavLink exact className={style.navLink} activeClassName={style.navLinkActive} to="/about">About</NavLink>
                    <NavLink exact className={style.navLink} activeClassName={style.navLinkActive} to="/dashboard">Dashboard</NavLink>
                </nav>
            </header> 
                 
            <main className={style.main}>
                <Switch>
                    <Route exact path="/">
                        <Flow />
                    </Route>
                    <Route path="/about">
                    <div>
                        about
                    </div>
                    </Route>
                    <Route path="/dashboard">
                        <div>
                            dashboard
                        </div>
                    </Route>
                </Switch>
            </main>

            <footer className={style.footer} />
        </div>
    </Router>
);

export default App;