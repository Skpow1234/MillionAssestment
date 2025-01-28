import Link from 'next/link';

const Navbar: React.FC = () => {
    return (
        <nav style={{ padding: '1rem', borderBottom: '1px solid #ccc' }}>
            <Link href="/">Home</Link> | <Link href="/properties">Properties</Link>
        </nav>
    );
};

export default Navbar;
