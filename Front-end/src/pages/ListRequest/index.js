import Table from './table';

import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';

const ListRequest = () => {
    const navigate = useNavigate();
    const role = localStorage.getItem('role');
    useEffect(() => {
        if (role!=='Employee')
        {
        navigate('/');
        }
    }, []);
    return (
        <div style={{ paddingLeft: '260px' }}>
            <Table />
        </div>
    );
};

export default ListRequest;
