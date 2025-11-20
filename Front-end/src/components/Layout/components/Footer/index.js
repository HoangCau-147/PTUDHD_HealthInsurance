import classNames from 'classnames/bind';
import styles from './Footer.module.scss';

const cx = classNames.bind(styles);

function Footer() {
    return (
        <footer className={cx('wrapper')}>
            © Nhóm 6 - Đồ án Bảo hiểm sức khỏe, Phân tích hệ thống thông tin hiện đại - HCMUS. Hotline: (+84) 5718 717
        </footer>
    );
}

export default Footer;
