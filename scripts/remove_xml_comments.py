import logging
import os
from pathlib import Path
import shutil
import sys

from lxml import etree

logger = logging.getLogger(__name__)

USAGE: str = f"""
Usage. Recursively delete xml comments in the all xml files in the assets
directory passed in the first argument. Cleaned up files will be written
to the directory passed in the second argument.

It needs to activate environment at first (run "pipenv shell")'

Example:

pipenv shell
python {sys.argv[0]} /home/$USER/my-game-assets /tmp/thegame/my-game-assets-cleared-up
"""

def main():
    if len(sys.argv) != 3:
        logger.error('Not all arguments were passed')
        print(USAGE)
        sys.exit(1)

    if not os.environ.get('VIRTUAL_ENV', ''):
        logger.error(f'The virtual environment is not activated (run "pipenv shell")')
        print(USAGE)
        sys.exit(1)

    assets_dir = Path(sys.argv[1])
    dst_dir = Path(sys.argv[2])
    if not assets_dir.exists():
        logger.error(f'There is no assets directory "{assets_dir}"')
        print(USAGE)
        sys.exit(1)

    # if assets_dir == dst_dir:
    #     logger.error(f'The assets directory and the destination directory is the same')
    #     print(USAGE)
    #     sys.exit(1)

    # if dst_dir.exists():
    #     logger.info(f'The destination directory exists. Remove it (dst_dir = "{dst_dir}"')
    #     if dst_dir.is_file():
    #         dst_dir.unlink()
    #     else:
    #         shutil.rmtree(str(dst_dir))

    assets_dir = Path(str(assets_dir).rstrip('/').rstrip('\\'))
    for dirpath, dirnames, filenames in os.walk(assets_dir):
        relative_path = Path(str(dirpath)[len(str(assets_dir)):].strip('/').strip('\\'))
        for filename in filenames:
            path = Path(os.path.join(dirpath, filename))
            if '.xml' in path.suffixes or '.def' in path.suffixes:
                with path.open() as fh:
                    parser =  etree.XMLParser(remove_comments=True)
                    tree = etree.parse(fh, parser)
                dst_path = dst_dir / relative_path / filename
                dst_path.parent.mkdir(parents=True, exist_ok=True)
                with dst_path.open('w') as fh:
                    fh.write(etree.tostring(tree).decode())


if __name__ == '__main__':
    main()
