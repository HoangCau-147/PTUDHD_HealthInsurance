import Sidebar from '../components/Sidebar';
import { ToastContainer } from 'react-toastify';

function DefaultLayout({ children }) {
    return (
        <div>
            <Sidebar />
            <div>{children}</div>
            <ToastContainer />
        </div>
    );
}

export default DefaultLayout;
