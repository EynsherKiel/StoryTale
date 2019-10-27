import * as React from 'react'; 
import { Flow } from './Graph/Flow';
import style from "./App.module.css"

const App: React.FC = () => (
    <div>
        <div className={style.block}>
            <Flow />
        </div>
    </div>
);

export default App;