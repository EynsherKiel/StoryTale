import * as React from 'react'; 
import { Flow } from './Graph/Flow';
import style from "./App.module.css"

const App: React.FC = () => (
    <div>
        <div className={style.wrapper}> 
            <div className={style.three}><Flow /></div>
            <div className={style.one}><Flow /></div>
            <div className={style.two}><Flow /></div>
            <div className={style.four}><Flow /></div>
            <div className={style.five}><Flow /></div>
            <div className={style.six}><Flow /></div> 
        </div>
    </div>
);

export default App;