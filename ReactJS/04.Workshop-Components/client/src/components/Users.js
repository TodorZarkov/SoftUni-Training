import Search from './Search';
import Overlap from './overlap/Overlap';
import TableHead from './TableHead';
import UserRow from './UserRow';
import Pagination from './Pagination';

export default function Users() {
    return (
        <section className="card users-container">

            <Search />

            <div className="table-wrapper">

                {/* Overlap components */}
                {/* <Overlap /> */}

                <table className="table">
                    <TableHead />
                    <tbody>
                        <UserRow />
                    </tbody>
                </table>

            </div>

            <button className="btn-add btn">Add new user</button>

            <Pagination />

        </section>
    );
};