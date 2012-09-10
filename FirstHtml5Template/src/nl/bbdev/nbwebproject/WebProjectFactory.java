package nl.bbdev.nbwebproject;

import java.io.IOException;
import org.netbeans.api.project.Project;
import org.netbeans.spi.project.ProjectFactory;
import org.netbeans.spi.project.ProjectState;
import org.openide.filesystems.FileObject;
import org.openide.util.lookup.ServiceProvider;

/**
 *
 * @author Bram Borggreve <borggreve@gmail.com>
 */
@ServiceProvider(service = ProjectFactory.class)
public class WebProjectFactory implements ProjectFactory {

    public static final String PROJECT_FILE = "index.html";
        
    @Override
    public boolean isProject(FileObject projectDirectory) {
        return projectDirectory.getFileObject(PROJECT_FILE) != null;
    }

    @Override
    public Project loadProject(FileObject dir, ProjectState state) throws IOException {
        return isProject(dir) ? new WebProject(dir, state) : null;
    }

    @Override
    public void saveProject(Project prjct) throws IOException, ClassCastException {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
