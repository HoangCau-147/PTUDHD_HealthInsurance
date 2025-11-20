import styles from './HeaderOnly.module.scss';
import classNames from 'classnames/bind';

const cx = classNames.bind(styles);

function DefaultLayout({ children }) {
    return (
        <div className={cx('wrapper')}>
            <div className={cx('container')}>{children}</div>
        </div>
    );
}

export default DefaultLayout;
